using DesignPatterns.Business.ProxyPattern.Contracts;
using DesignPatterns.Business.ProxyPattern.Enums;
using DesignPatterns.Business.ProxyPattern.Models;

namespace DesignPatterns.Business.ProxyPattern.Implementation
{
    public class SharedFolderProxy : ISharedFolder
    {
        public SharedFolderProxy(Employee employee)
        {
            this.employee = employee;
        }

        public string PerformReadOperation()
        {
            if (employee.RoleType == RoleType.CEO || employee.RoleType == RoleType.MANAGER)
            {
                folder = new SharedFolder();
                Message = "Shared folder proxy makes call to the read folder 'Perform read operation' method: ";
                var specificMessage = folder.PerformReadOperation();
                Message += specificMessage;
            }
            else
            {
                Message = "Shared folder proxy says 'You don't have the permission to read items on this folder'";
            }

            return Message;
        }

        public string PerformWriteOperation()
        {
            if (employee.RoleType == RoleType.CEO)
            {
                folder = new SharedFolder();
                Message = "Shared folder proxy makes call to the write folder 'Perform write operation' method: ";
                var specificMessage = folder.PerformWriteOperation();
                Message += specificMessage;
            }
            else
            {
                Message = "Shared folder proxy says 'You don't have the permission to write to this folder'";
            }

            return Message;
        }

        //

        private ISharedFolder folder;
        private readonly Employee employee;

        private string Message { get; set; }
    }
}
