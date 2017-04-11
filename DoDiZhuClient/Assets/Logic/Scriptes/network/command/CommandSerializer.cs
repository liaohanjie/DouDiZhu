using System.Collections.Generic;
using Assets.Scripts.NewNetWork.common;

namespace Assets.Scripts.NewNetWork.Command
{
   public class CommandSerializer 
    {
        private static Dictionary<int, ICommand> commandMap = new Dictionary<int, ICommand>();

        
        public static byte[] encode(ICommand command)
        {
            if(command != null)
            {
                byte[] bytes = command.write();
                int totalLen = command.getHead().getHeadLength();
                if(bytes != null)
                {
                    totalLen += bytes.Length;
                }
                ByteBuffer byteBuff = ByteBuffer.Allocate(totalLen);
                byteBuff.WriteInt(totalLen);
                byteBuff.WriteInt(checkCode(totalLen));
                
            }
            
            return null;
        }
        /// <summary>
        /// 对包体进行md5加密，制作数据接要。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static byte[] degist(byte[] bytes)
        {
            return bytes;
        }

        private static int checkCode(int totalLen)
        {
            return totalLen ^ 128 + 123;
        }

        public static ICommand decode(byte[] bytes)
        {
            return null;
        }

    }
}
