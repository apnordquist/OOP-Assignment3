using OOP_Assignment3;
using OOP_Assignment3.ProblemDomain;
using System.Diagnostics.CodeAnalysis;

namespace Assignment3_Tests
{
    public class Tests
    {
        private UserLinkedList<User> TestList;
        private UserLinkedList<User> RevList;
        [SetUp]
        public void Setup()
        {
            //Create Lists
            TestList = new UserLinkedList<User>();
            RevList = new UserLinkedList<User>();
            //Create Users
            User TestUser1 = new User(99,"John","Beatle1@gmail.com", "");
            User TestUser2 = new User(98,"Paul", "Wings@gmail.com", "");
            User TestUser3 = new User(97,"Ringo", "Starke@gmail.com", "");
            User TestUser4 = new User(96,"George", "Harrison@gmail.com", "");
            //populate first list
            TestList.AddLast(TestUser1);
            TestList.AddLast(TestUser2);
            TestList.AddLast(TestUser3);
            TestList.AddLast(TestUser4);
            //populate second list
            RevList.AddFirst(TestUser1);
            RevList.AddFirst(TestUser2);
            RevList.AddFirst(TestUser3);
            RevList.AddFirst(TestUser4);
        }

        [Test]
        public void TestIsEmpty()
        {
            bool result = TestList.IsEmpty(); //check if empty
            Assert.IsFalse(result); // return false if test list was created
        }

        [Test]
        public void TestClear()
        {
            TestList.Clear(); //empty list
            Assert.AreEqual(null, TestList.Head); //confirm by seeing if head is null
        }

        [Test]
        public void TestAddLast()
        {
            User expected = new User(2,"Joseph","macintosh@apple.com","12345"); //new user
            TestList.AddLast(expected); 
            User result = TestList.Tail.Data; //get last item after operation
            Assert.AreEqual(expected, result); //confirm addition
        }

        [Test]
        public void TestAddFirst()
        {
            User expected = new User(3, "Marcus", "alphabet@gmail.com", "password"); //new user
            TestList.AddFirst(expected);
            User result = TestList.Head.Data; //get first item after operation
            Assert.AreEqual(expected, result); //confirm addition
        }

        [Test]
        public void TestAddatIndex()
        {
            User expected = new User(1, "Harvey", "neverlate@me.com", "awesome1"); //new user
            TestList.Add(expected, 3);
            User result = TestList.GetValue(3); //get iteam at index after operation
            Assert.AreEqual(expected, result); //confirm addition
        }

        [Test]
        public void TestReplaceatIndex()
        {
            User expected = new User(5, "James", "Brown@outlook.com", "IFeelGood"); //new user
            TestList.Replace(expected, 2);
            User result = TestList.GetValue(2); //get iteam at index after operation
            Assert.AreEqual(expected, result); //confirm addition
        }

        [Test]
        public void TestCount()
        {
            int result = TestList.Count(); //get counter variable
            int expected = 4; //length of test list
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestRemoveFirst()
        {
            User expected = TestList.Head.Data; //get first item before operation
            TestList.RemoveFirst();
            User result = TestList.Head.Data; //get first item after operation
            Assert.AreNotEqual(expected, result); //confirm removal
        }

        [Test]
        public void TestRemoveLast()
        {
            User expected = TestList.Tail.Data; //get last item before operation
            TestList.RemoveLast();
            User result = TestList.Tail.Data; //get last item after operation
            Assert.AreNotEqual(expected, result); //confirm removal
        }

        [Test]
        public void TestRemoveatIndex()
        {
            User expected = TestList.GetValue(2); //get item at index before operation
            TestList.Remove(2);
            User result = TestList.GetValue(2); //get item at index after operation
            Assert.AreNotEqual(expected, result); //confirm removal
        }

        [Test]
        public void TestGetValue()
        {
            User TestUser2 = new User(98, "Paul", "Wings@gmail.com", ""); //from testlist
            User expected = TestUser2; //set expected user
            User result = TestList.GetValue(1);
            Assert.AreEqual(expected, result); //confirm right user
        }

        [Test]
        public void TestIndexOf()
        {
            User TestUser3 = new User(97, "Ringo", "Starke@gmail.com", ""); //from testlist
            int expected = 2; //position in list
            int result = TestList.IndexOf(TestUser3);
            Assert.AreEqual(expected, result); //confirm right position
        }

        [Test]
        public void TestContains()
        {
            User TestUser4 = new User(96, "George", "Harrison@gmail.com", ""); //from testlist
            bool result = TestList.Contains(TestUser4);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestReverseOrder()
        {
            User expected = TestList.Head.Data; //get the first value
            TestList.ReverseOrder();
            User result = TestList.Tail.Data; //get the new last value
            Assert.AreEqual(expected, result); //see if the first and last match after operation
        }

        [Test]
        public void TestJoinLists()
        {
            int expected = 8; //expected list length
            TestList.JoinList(RevList); //add the rev list to the testlist
            int result = TestList.Count(); //get new length
            Assert.AreEqual(expected, result);
        }
    }
}