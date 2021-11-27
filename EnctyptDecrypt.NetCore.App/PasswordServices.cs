using EnctyptDecrypt.NetCore.App.Security;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnctyptDecrypt.NetCore.App
{
    internal class PasswordServices
    {
        private readonly IDataProtector _dataProtector;
        public PasswordServices(IDataProtectionProvider dataProtectionProvider, DataProtectionPurposes dataProtectionPurposes)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(dataProtectionPurposes.PasswordEnctyption);
        }

        public string EncryptString (string data)
        {
            return _dataProtector.Protect(data);
        }

        public string Decrypt(string encryptedData)
        {
            return _dataProtector.Unprotect(encryptedData);
        }
    }
}
