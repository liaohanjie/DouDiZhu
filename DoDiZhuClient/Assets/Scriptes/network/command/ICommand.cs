using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.NewNetWork.common;

namespace Assets.Scripts.NewNetWork.Command
{
   public interface ICommand
    {
        CommandHead getHead();
        //获取包体的数据        
        byte[] write();
        /**
         * 
         * @Desc  描述：从缓冲区读取数据
         * @return   
         * @author wang guang shuai
         * @date 2016年9月18日 上午9:42:52
         *
         */
        void read(ByteBuffer buffer);
        int getCommandId();
    }
}
