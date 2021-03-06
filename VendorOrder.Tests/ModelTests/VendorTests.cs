using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using VendorOrder.Models;

namespace VendorOrder.Tests {
  [TestClass]
  public class VendorTests : IDisposable {
    public void Dispose() {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreateInstanceOfVendor_Vendor() {  
      //Arrange
      Vendor testVendor = new Vendor("title", "description");
      //Act
      //Assert
      Assert.AreEqual(typeof(Vendor), testVendor.GetType());
    }
    [TestMethod]
    public void VendorDetails_ReturnsDetails_String()
    {
      //Arrange
      string name = "test";
      string description = "description";
      Vendor testVendor = new Vendor(name, description);
      //Act
      string result = testVendor.Name;
      //Assert
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void ClearAllGetAll_ClearStaticList_VendorList() {
      //Arrange
      List<Vendor> testList = new List<Vendor> {};
      //Act
      List<Vendor> result = Vendor.GetAll();
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsVendors_VendorList() {
      //Arrange
      string title = "title";
      string description = "description";
      Vendor testVendor1 = new Vendor(title, description);
      Vendor testVendor2 = new Vendor(title, description);
      List<Vendor>  testList = new List<Vendor> { testVendor1, testVendor2 };
      //Act
      List<Vendor> result = Vendor.GetAll();
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void AssignId_AssignIdToIstantiatedVendor_Int() {
      //Arrange
      string title = "title";
      string description = "description";
      Vendor testVendor = new Vendor(title, description);
      //Act
      int result = testVendor.Id;
      //Assert
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void Find_FindsVendorById_Vendor() {
      //Arrange
      string title = "title";
      string description = "description";
      Vendor testVendor1 = new Vendor(title, description);
      Vendor testVendor2 = new Vendor(title, description);
      //Act
      Vendor result = Vendor.Find(2);
      //Assert
      Assert.AreEqual(testVendor2, result);
    }
    [TestMethod]
    public void AddOrder_AssociateOrdersWithVendor_OrderList() {
      //Arrange
      Order testOrder = new  Order("title", "description", 100, "date");
      List<Order> testList = new List<Order> { testOrder };
      Vendor testVendor = new Vendor("title", "description");
      testVendor.AddOrder(testOrder);
      //Act
      List<Order> result = testVendor.Orders;
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}