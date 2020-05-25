using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class OpcUaClient
{

    public Session session { get; set; }
    public List<MonitoredItem> list { get; set; }


    public void SubscripeToOpcUaServer(string OpcUaEndpoint, List<string> NoteIdList)
    {
        var config = new ApplicationConfiguration()
        {
            ApplicationName = "OpcUaClientconifg",
            ApplicationUri = Utils.Format(@"urn:{0}:OpcUaClient", System.Net.Dns.GetHostName()),
            ApplicationType = ApplicationType.Client,
            SecurityConfiguration = new SecurityConfiguration
            {
                ApplicationCertificate = new CertificateIdentifier { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault", SubjectName = Utils.Format(@"CN={0}, DC={1}", "MyHomework", System.Net.Dns.GetHostName()) },
                TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities" },
                TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications" },
                RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates" },
                AutoAcceptUntrustedCertificates = true,
                AddAppCertToTrustedStore = true,
                RejectSHA1SignedCertificates = false,
                MinimumCertificateKeySize = 1024
            },
            TransportConfigurations = new TransportConfigurationCollection(),
            TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
            ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
            TraceConfiguration = new TraceConfiguration()
        };


        config.Validate(ApplicationType.Client).GetAwaiter().GetResult();
        if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
        {
            config.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted); };
        }


        var application = new ApplicationInstance
        {
            ApplicationName = "OpcUaClient",
            ApplicationType = ApplicationType.Client,
            ApplicationConfiguration = config
        };

        application.CheckApplicationInstanceCertificate(false, 2048).GetAwaiter().GetResult();


        var selectedEndpoint = CoreClientUtils.SelectEndpoint(OpcUaEndpoint, useSecurity: false, operationTimeout: 15000); //"opc.tcp://141.60.104.13:4840"


        session = Session.Create(config, new ConfiguredEndpoint(null, selectedEndpoint, EndpointConfiguration.Create(config)), false, "", 60000, null, null).GetAwaiter().GetResult();
        {
            ReferenceDescriptionCollection refs;
            Byte[] cp;
            session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out cp, out refs);
            foreach (var rd in refs)
            {
                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;
                session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);
            }

            var subscription = new Subscription(session.DefaultSubscription) { PublishingInterval = 1000 };


            list = new List<MonitoredItem>();
            foreach (var item in NoteIdList)
            {
                var monitoredItem = new MonitoredItem(subscription.DefaultItem)
                {
                    StartNodeId = item
                };

                list.Add(monitoredItem);
            }
            subscription.AddItems(list);
            session.AddSubscription(subscription);
            subscription.Create();
        }
    }

    public void WriteOpcUaNode(string NamespaceAndNode, bool booleanValue)
    {

        StatusCodeCollection results = null;
        DiagnosticInfoCollection diagnosticInfos = null;
        WriteValueCollection writeValues = new WriteValueCollection();
        // Int32 Item
        WriteValue WriteVal = new WriteValue
        {
            NodeId = new NodeId(NamespaceAndNode),
            AttributeId = Attributes.Value,
            Value = new DataValue(booleanValue)
        };

        writeValues.Add(WriteVal);
        // Call the Write service
        ResponseHeader responseHeader = session.Write(null, writeValues, out results, out diagnosticInfos);
    }

    public void WriteOpcUaFloatNode(string NamespaceAndNode, float value)
    {

        StatusCodeCollection results = null;
        DiagnosticInfoCollection diagnosticInfos = null;
        WriteValueCollection writeValues = new WriteValueCollection();
        // Int32 Item
        WriteValue WriteVal = new WriteValue
        {
            NodeId = new NodeId(NamespaceAndNode),
            AttributeId = Attributes.Value,
            Value = new DataValue(value)
        };

        writeValues.Add(WriteVal);
        // Call the Write service
        ResponseHeader responseHeader = session.Write(null, writeValues, out results, out diagnosticInfos);
    }
}
