using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Assets.Scripts.NewNetWork.common;
using ProtoBuf;

namespace Assets.Scripts.NewNetWork.Command
{
    public abstract class AbstractCommand : ICommand
    {
        private CommandHead commandHead = new CommandHead();

        public CommandHead getHead()
        {
            return commandHead;
        }

        public byte[] write()
        {
            ProtoBuf.IExtensible protoMsg = this.getGenerateMessage();
            if(protoMsg != null)
            {
                byte[] result = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    Serializer.Serialize(ms, protoMsg);
                    result = ms.ToArray();
                }
                return result;
            }
            return null;
        }

      

        public void read(ByteBuffer buffer)
        {
            int remainLen = buffer.ReadableBytes();
            if(remainLen > 0)
            {
                byte[] bytes = buffer.ReadBytes(remainLen);
                parseFromBytes(bytes);
            }
            

        }

        public abstract int getCommandId();
        /**
         * 把bytes信息转化为protobuf信息
         */
        protected abstract void parseFromBytes(byte[] bytes);

        /**
         * 从子类获取protobuf的数据
         */
        protected abstract ProtoBuf.IExtensible getGenerateMessage();
    }
}
