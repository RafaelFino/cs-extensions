

using Extensions.Utils;

var logger = new Logger();
var ctxFactory = new ContextFactory(logger);

try
{
    using (var ctx = ctxFactory.Create("Main"))
    {
        logger.Info("Starting main process {Environment.NewLine}");

        for(int i=0; i < 10; i++)
        {
            logger.Info($"[{i}] Starting iteration");

            using (var ctx1 = ctxFactory.Create("Function1"))
            {
                logger.Info($"[{i}] Doing some work with 100ms delay");    
                Thread.Sleep(100);
            }

            using (var ctx2 = ctxFactory.Create("Function2"))
            {
                logger.Info($"[{i}] Doing other some work with 200ms delay..");  
                Thread.Sleep(200);
            }

            logger.Info($"[{i}] Ending iteration{Environment.NewLine}");
        }
    }
}
catch(Exception ex)
{
    logger.Error(ex.Message);
}