﻿using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models
{
    public class TrademarkDto : Dto, IIdentifiableDto
    {
        public string                           Id                  {
                                                                        get { return $"{ApplicationNumber}|{Registry}"; }
                                                                        set { }
                                                                    } // Thx Luis, you are my hero! #@!%&&!!!

        [JsonProperty("application_number")]
        public string                           ApplicationNumber   { get; set; }
        [JsonProperty("registration_date")]
        public DateTime?                        RegistrationDate    { set; get; }
        [JsonProperty("application_date")]
        public DateTime                         ApplicationDate     { set; get; }
        [JsonProperty("expiry_date")]
        public DateTime?                        ExpiryDate          { get; set; }
        [JsonProperty("mark_feature")]
        public string                           MarkFeature         { set; get; }
        [JsonProperty("kind_mark")]
        public string                           KindMark            { get; set; }
        [JsonProperty("mark_text")]
        public string                           MarkText            { get; set; }
        public string                           Classes             { get; set; }
        public string                           Status              { get; set; }
        public string                           Registry            { get; set; }
        [JsonProperty("good_and_services")]
        public ICollection<GoodAndServiceDto>   GoodAndServices     { get; set; }
        public ICollection<EntityDbo>           Applicants          { get; set; }
        public ICollection<EntityDbo>           Representatives     { get; set; }
        
    }

    public class EntityDbo
    {
        public int          Id      { get; set; }
        public string       Name    { get; set; }
        public AddressDbo   Address { get; set; }
    }

    public class AddressDbo
    {
        [JsonProperty("post_code")]
        public string   Postcode    { get; set; }
        public string   Town        { get; set; }
        [JsonProperty("country_code")]
        public string   CountryCode { get; set; }

        public override string ToString()
        {
            return $"{Town}, {CountryCode} {Postcode}";
        }
    }

}