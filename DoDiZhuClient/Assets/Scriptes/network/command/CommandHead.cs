using Assets.Scripts.NewNetWork.common;

public class CommandHead  {
    // 包头的总长度
    public const int headLength = 24;
    private int commandId; //命令id
    private int clientSequenceId; //客户端消息序列id
    private int serverSequenceId;//服务器端消息id.
    private long sendTime;        //时间戳
    private int errorCode;        //错误码


    public int write(ByteBuffer ioBuffer)
    {

        ioBuffer.WriteInt(this.commandId);
        ioBuffer.WriteInt(this.clientSequenceId);
        ioBuffer.WriteInt(this.serverSequenceId);
        ioBuffer.WriteLong(this.sendTime);
        ioBuffer.WriteInt(this.errorCode);
        return headLength;
    }

    public void read(ByteBuffer ioBuffer)
    {
        this.commandId = ioBuffer.ReadInt();
        this.clientSequenceId = ioBuffer.ReadInt();
        this.serverSequenceId = ioBuffer.ReadInt();
        this.sendTime = ioBuffer.ReadLong();
        this.errorCode = ioBuffer.ReadInt();
    }

    public void setClientSequenceId(int sequenceId)
    {
        this.clientSequenceId = sequenceId;
    }

    public int getClientSequenceId()
    {
        return this.clientSequenceId;
    }

    public void setServerSequenceId(int seqenuceId)
    {
        this.serverSequenceId = seqenuceId;
    }
    public int getServerSequenceId()
    {
        return serverSequenceId;
    }

    /**
	 * @param commandId the commandId to set
	 */
    public void setCommandId(int commandId)
    {
        this.commandId = commandId;
    }
    /**
	 * 
	 * @Desc  描述：获取包头的总长度
	 * @return   
	 * @author wang guang shuai
	 * @date 2016年9月18日 上午9:39:36
	 *
	 */
    public int getHeadLength()
    {
        return headLength;
    }

   
    /**
	 * @return the commandId
	 */
    public int getCommandId()
    {
        return commandId;
    }
    /**
	 * @return the sendTime
	 */
    public long getSendTime()
    {
        return sendTime;
    }
    /**
	 * @param sendTime the sendTime to set
	 */
    public void setSendTime(long sendTime)
    {
        this.sendTime = sendTime;
    }
    /**
	 * @return the errorCode
	 */
    public int getErrorCode()
    {
        return errorCode;
    }
    /**
	 * @param errorCode the errorCode to set
	 */
    public void setErrorCode(int errorCode)
    {
        this.errorCode = errorCode;
    }





}
