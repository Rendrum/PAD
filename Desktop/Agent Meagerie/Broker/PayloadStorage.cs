using Common;
using System.Collections.Concurrent;

namespace Broker
{
    static class PayloadStorage
    {
        private static ConcurrentQueue<Payload> _pauloadQueue;

        static PayloadStorage()
        {
            _pauloadQueue = new ConcurrentQueue<Payload>();
        }

        public static void Add(Payload payload)
        {
            _pauloadQueue.Enqueue(payload);
        }

        public static Payload GetNext()
        {
            Payload payload = null;
            _pauloadQueue.TryDequeue(out payload);

            return payload;
        }

        public static bool IsEmpty()
        {
            return _pauloadQueue.IsEmpty;
        }
    }
}
