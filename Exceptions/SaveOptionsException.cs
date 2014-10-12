using System;
using System.Runtime.Serialization;

namespace SQLt
{
    [Serializable]
    public class SaveOptionsException : CustomException, ISerializable
    {
    }

    [Serializable]
    public class LoadOptionsException : CustomException, ISerializable
    {
    }

    [Serializable]
    public class CustomException : Exception, ISerializable
    {
        public CustomException()
            : base()
        {
        }

        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CustomException(string format, Exception inner, params object[] args)
            : base(string.Format(format, args), inner)
        {
        }

        public CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}