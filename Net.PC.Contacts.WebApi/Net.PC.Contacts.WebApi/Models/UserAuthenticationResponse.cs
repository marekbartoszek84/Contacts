﻿namespace Net.PC.Contacts.WebApi.Models
{
    public class UserAuthenticationResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
