using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using log4net;
using UsageTkAuth;
using Vk.DTO.Domain;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Api;
using Vk.DTO.Controllers;
using Vk.Interfaces.ViewModels;
using User = UsageTkAuth.User;
namespace Vk.DTO.Test
{

    internal class Program
    {
        private static IVkApi api;
        private static readonly ILog log = LogManager.GetLogger(typeof (Program));
        private static MessageController _controller;

        private static void Main(string[] args)
        {

            EnumTest t = new EnumTest((ABCD) AB.A);
            Console.WriteLine(t.name);
            Console.ReadLine();
            }
            
        }

    public class EnumTest
    {
        public ABCD name;

        public EnumTest(ABCD n)
        {
            this.name = n;
        }
    }

    public enum ABCD
    {
        A,
        B,
        C,
        D,
    }

    public enum AB
    {
        A,
        B,
    }

    public enum CD
    {
        C,
        D,
    }

    }