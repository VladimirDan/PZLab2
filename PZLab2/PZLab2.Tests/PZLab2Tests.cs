using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PZLab2.Tests
{
    [TestClass]
    public class PZLab2Tests
    {
        [TestMethod]
        public void TestListLength_EmptyList_ReturnsZero()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            int length = list.ListLength();
            Assert.AreEqual(0, length);
        }

        [TestMethod]
        public void TestAppend_AddOneElement_ListLengthIsOne()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            int length = list.ListLength();
            Assert.AreEqual(1, length);
        }

        [TestMethod]
        public void TestAppend_AddThreeElements_ListLengthIsThree()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            int length = list.ListLength();
            Assert.AreEqual(3, length);
        }

        [TestMethod]
        public void TestInsert_InsertAtBeginning_ElementIsInsertedAtIndexZero()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('b');
            list.Insert('a', 0);
            char value = list.Get(0);
            Assert.AreEqual('a', value);
        }

        [TestMethod]
        public void TestInsert_InsertAtEnd_ElementIsInsertedAtEnd()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Insert('c', 2);
            char value = list.Get(2);
            Assert.AreEqual('c', value);
        }

        [TestMethod]
        public void TestInsert_InsertAtMiddle_ElementIsInsertedAtIndexOne()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('c');
            list.Insert('b', 1);
            char value = list.Get(1);
            Assert.AreEqual('b', value);
        }

        [TestMethod]
        public void TestDelete_DeleteAtBeginning_ElementIsDeleted()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            char deletedValue = list.Delete(0);
            Assert.AreEqual('a', deletedValue);
        }

        [TestMethod]
        public void TestDelete_DeleteAtEnd_ElementIsDeleted()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            char deletedValue = list.Delete(1);
            Assert.AreEqual('b', deletedValue);
        }

        [TestMethod]
        public void TestDelete_DeleteAtMiddle_ElementIsDeleted()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            char deletedValue = list.Delete(1);
            Assert.AreEqual('b', deletedValue);
        }

        [TestMethod]
        public void TestDeleteAll_DeleteAllOccurences_ListDoesNotContainDeletedElement()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Append('a');
            list.Append('c');
            list.DeleteAll('a');
            Assert.AreEqual(2, list.ListLength());
            Assert.AreEqual('b', list.Get(0));
            Assert.AreEqual('c', list.Get(1));
        }

        [TestMethod]
        public void TestDeleteAll_RemovesAllMatchingElements_FromList()
        {
            var list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            list.Append('b');
            list.Append('d');
            list.DeleteAll('b');
            Assert.AreEqual(3, list.ListLength());
            Assert.AreEqual('a', list.Get(0));
            Assert.AreEqual('c', list.Get(1));
            Assert.AreEqual('d', list.Get(2));
        }

        [TestMethod]
        public void TestGet_ReturnsValueAtIndex()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            char valueAtIndex = list.Get(1);
            Assert.AreEqual('b', valueAtIndex);
        }

        [TestMethod]
        public void TestGet_ThrowsExceptionForInvalidIndex()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.Append('a');
            Assert.ThrowsException<Exception>(() => list.Get(1));
        }

        [TestMethod]
        public void TestClone_CreatesNewList_WithSameElements()
        {
            var list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            var newList = list.Clone();
            Assert.AreEqual(list.ListLength(), newList.ListLength());
            Assert.AreEqual(list.Get(0), newList.Get(0));
            Assert.AreEqual(list.Get(1), newList.Get(1));
            Assert.AreEqual(list.Get(2), newList.Get(2));
        }

        [TestMethod]
        public void TestReverse_ReversesOrder_OfElementsInList()
        {
            var list = new DoublyLinkedList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            list.Reverse();
            Assert.AreEqual(3, list.ListLength());
            Assert.AreEqual('c', list.Get(0));
            Assert.AreEqual('b', list.Get(1));
            Assert.AreEqual('a', list.Get(2));
        }

        [TestMethod]
        public void TestFindFirst_ReturnsIndexOfFirstMatchingNode()
        {
            var list = new DoublyLinkedList();
            list.Append('A');
            list.Append('B');
            list.Append('C');
            list.Append('B');
            list.Append('D');
            var index = list.FindFirst('B');
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void TestFindLast_ReturnsIndexOfLastMatchingNode()
        {
            var list = new DoublyLinkedList();
            list.Append('A');
            list.Append('B');
            list.Append('C');
            list.Append('B');
            list.Append('D');
            var index = list.FindLast('B');
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void TestClear_RemovesAllNodesFromList()
        {
            var list = new DoublyLinkedList();
            list.Append('A');
            list.Append('B');
            list.Append('C');
            list.Clear();
            Assert.AreEqual(0, list.ListLength());
            Assert.ThrowsException<Exception>(() => list.Get(0));
        }

        [TestMethod]
        public void TestExtend_AddsNodesFromSecondListToEndOfFirstList()
        {
            var firstList = new DoublyLinkedList();
            firstList.Append('A');
            firstList.Append('B');
            var secondList = new DoublyLinkedList();
            secondList.Append('C');
            secondList.Append('D');
            firstList.Extend(secondList);
            Assert.AreEqual(4, firstList.ListLength());
            Assert.AreEqual('C', firstList.Get(2));
            Assert.AreEqual('D', firstList.Get(3));
        }
    }
}

