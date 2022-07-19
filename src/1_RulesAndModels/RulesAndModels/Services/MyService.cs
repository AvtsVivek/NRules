﻿namespace RulesAndModels.Services
{
    public interface IService
    {
        void MyMethod();
    }
    public class MyService : IService
    {
        public MyService()
        {

        }

        public void MyMethod()
        {

        }
    }

    public class MyLoggingService : IService
    {
        private readonly IService _service;
        public MyLoggingService(IService service)
        {
            _service = service;
        }

        public void MyMethod()
        {
            _service.MyMethod();
        }
    }

    public class MyExceptionHandlingService : IService
    {
        private readonly IService _service;
        public MyExceptionHandlingService(IService service)
        {
            _service = service;
        }

        public void MyMethod()
        {
            _service.MyMethod();
        }
    }
}
