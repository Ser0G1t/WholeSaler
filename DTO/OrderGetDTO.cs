﻿using WholeSaler.Entity;
using WholeSaler.Enum;

namespace WholeSaler.DTO
{
    public record OrderGetDTO
    {
        public OrderStatus Status { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
