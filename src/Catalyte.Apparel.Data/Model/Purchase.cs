﻿//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace Catalyte.Apparel.Data.Model
//{
//    /// <summary>
//    /// Describes a purchase object that holds the information for a transaction.
//    /// </summary>
//    public class Purchase : BaseEntity
//    {
//        public DateTime OrderDate { get; set; }

//        public decimal TotalCost { get; set; }

//        [MaxLength(100)]
//        public string BillingStreet { get; set; }

//        [MaxLength(100)]
//        public string BillingStreet2 { get; set; }

//        [MaxLength(50)]
//        public string BillingCity { get; set; }

//        public string BillingState { get; set; }

//        [MaxLength(11)]
//        public string BillingZip { get; set; }

//        [MaxLength(100)]
//        public string BillingEmail { get; set; }

//        [MaxLength(15)]
//        public string BillingPhone { get; set; }

//        [MaxLength(50)]
//        public string DeliveryFirstName { get; set; }

//        [MaxLength(50)]
//        public string DeliveryLastName { get; set; }

//        [MaxLength(100)]
//        public string DeliveryStreet { get; set; }

//        [MaxLength(100)]
//        public string DeliveryStreet2 { get; set; }

//        [MaxLength(50)]
//        public string DeliveryCity { get; set; }

//        public string DeliveryState { get; set; }

//        [MaxLength(11)]
//        public string DeliveryZip { get; set; }

//        [MaxLength(19)]
//        public string CardNumber { get; set; }

//        public string CVV { get; set; }

//        [MaxLength(5)]
//        public string Expiration { get; set; }

//        [MaxLength(100)]
//        public string CardHolder { get; set; }

//    }
//}
