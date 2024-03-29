﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using OOP_Assignment3.ProblemDomain;
using OOP_Assignment3.Utility;
using OOP_Assignment3;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using NUnit.Framework.Internal.Execution;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(UserLinkedList<User> users, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static UserLinkedList<User> DeserializeUsers(string fileName)
        {
            string jsonData = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<UserLinkedList<User>>(jsonData);
        }
    }
}
