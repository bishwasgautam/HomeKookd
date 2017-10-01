//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace HomeKookd.Infrastructure
//{
//    public interface ISelfRegisterableDispatcher
//    {
//        List<ISelfRegisterableModule> Registerables { get; set; }

//        void Dispatch();

//        void RegisterModule(ISelfRegisterableModule module);
//    }

//    public interface ISelfRegisterableModule
//    {
//        void Register();
//    }

//    public class SelfRegisterableDispatcher : ISelfRegisterableDispatcher
//    {
//        public List<ISelfRegisterableModule> Registerables { get; set; }

//        public SelfRegisterableDispatcher()
//        {
//            Registerables = new List<ISelfRegisterableModule>();
//        }

//        public void Dispatch()
//        {
//            Registerables.ForEach(r => r.Register());
//        }

//        public void RegisterModule(ISelfRegisterableModule module)
//        {
//            Registerables.Add(module);
//        }
//    }

//    public class DataRegistration : ISelfRegisterableModule
//    {
//        public DataRegistration(IConfiguration configuration)
//        {
//            configuration.
//        }
//        public void Register()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
