using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.ProxyPattern.Enums;
using DesignPatterns.Business.ProxyPattern.Implementation;
using DesignPatterns.Business.ProxyPattern.Models;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ProxyPatternTests
    {
        [Test]
        public void ManagerCanPerformReadOperation()
        {
            var manager = new Employee("manager", RoleType.MANAGER);
            var folderProxy = new SharedFolderProxy(manager);
            var actual = folderProxy.PerformReadOperation();
            Assert.Equals(actual, "Shared folder proxy makes call to the read folder 'Perform read operation' method: Performing read operation on the shared folder");
        }

        [Test]
        public void ManagerCannotPerformWriteOperation()
        {
            var manager = new Employee("manager", RoleType.MANAGER);
            var folderProxy = new SharedFolderProxy(manager);
            var actual = folderProxy.PerformWriteOperation();
            Assert.Equals(actual, "Shared folder proxy says 'You don't have the permission to write to this folder'");
        }

        [Test]
        public void CEOCanPerformReadOperation()
        {
            var ceo = new Employee("CEO", RoleType.CEO);
            var folderProxy = new SharedFolderProxy(ceo);
            var actual = folderProxy.PerformReadOperation();
            Assert.Equals(actual, "Shared folder proxy makes call to the read folder 'Perform read operation' method: Performing read operation on the shared folder");
        }

        [Test]
        public void CEOCanPerformWriteOperation()
        {
            var ceo = new Employee("CEO", RoleType.CEO);
            var folderProxy = new SharedFolderProxy(ceo);
            var actual = folderProxy.PerformWriteOperation();
            Assert.Equals(actual, "Shared folder proxy makes call to the write folder 'Perform write operation' method: Performing write operation on the shared folder");
        }

    }
}
