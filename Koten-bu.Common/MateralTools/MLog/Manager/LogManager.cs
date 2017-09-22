namespace MateralTools.MLog.Manager
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    public class LogManager
    {
        /// <summary>
        /// Log保存类型
        /// </summary>
        private LogStorageMode _logStorageMode;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="lsm"></param>
        public LogManager(LogStorageMode lsm = LogStorageMode.Txt)
        {
            _logStorageMode = lsm;
            switch (_logStorageMode)
            {
                case LogStorageMode.Txt:
                    break;
                case LogStorageMode.XML:
                    break;
                case LogStorageMode.MSSSQL:
                    break;
                case LogStorageMode.SQLite:
                    break;
                default:
                    break;
            }
        }

    }
}
