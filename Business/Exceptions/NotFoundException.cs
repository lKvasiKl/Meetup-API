﻿namespace Business.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string massage)
            : base(massage)
        {

        }
    }
}
