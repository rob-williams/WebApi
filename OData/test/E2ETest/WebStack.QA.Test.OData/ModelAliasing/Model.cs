﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebStack.QA.Test.OData.ModelAliasing
{
    public class ModelAliasingMetadataCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ModelAliasingMetadataAddress BillingAddress { get; set; }
        public ModelAliasingMetadataAddress DefaultShippingAddress { get; set; }
        public IList<ModelAliasingMetadataOrder> Orders { get; set; }
    }

    [DataContract(Name = "MetadataOrder", Namespace = "Billing")]
    public class ModelAliasingMetadataOrder
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTimeOffset PurchaseDate { get; set; }
        [DataMember]
        public ModelAliasingMetadataAddress ShippingAddress { get; set; }
        [DataMember]
        public IList<ModelAliasingMetadataOrderLine> Details { get; set; }
    }

    [DataContract]
    public class ModelAliasingMetadataExpressOrder : ModelAliasingMetadataOrder
    {
        public double ExpressFee { get; set; }
        [DataMember(Name = "DeliveryDate")]
        public DateTimeOffset GuaranteedDeliveryDate { get; set; }
    }

    [DataContract(Name = "FreeDeliveryOrder", Namespace = "Billing")]
    public class ModelAliasingMetadataFreeDeliveryOrder : ModelAliasingMetadataOrder
    {
        public DateTimeOffset EstimatedDeliveryDate { get; set; }
    }

    [DataContract(Name = "OrderLine", Namespace = "Billing")]
    public class ModelAliasingMetadataOrderLine
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember(Name = "Product")]
        public ModelAliasingMetadataProduct Item { get; set; }
        [DataMember(Name = "Value")]
        public double Price { get; set; }
        [DataMember]
        public int Ammount { get; set; }
    }

    [DataContract(Name = "Product", Namespace = "Purchasing")]
    public class ModelAliasingMetadataProduct
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember(Name = "ProductName")]
        public string Name { get; set; }
        [DataMember(Name = "AvailableRegions")]
        public IList<ModelAliasingMetadataRegion> Regions { get; set; }
    }

    public class ModelAliasingMetadataAddress
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public ModelAliasingMetadataRegion Country { get; set; }
    }

    public class ModelAliasingMetadataRegion
    {
        public string Country { get; set; }
        public string State { get; set; }
    }
}
