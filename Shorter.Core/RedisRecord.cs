using StackExchange.Redis;

namespace Shorter.Core
{
    public class RedisRecord
    {
        public RedisKey Key { get; set; }
        public RedisValue Value { get; set; }

        public RedisRecord()
        {

        }

        public RedisRecord(RedisKey key, RedisValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
