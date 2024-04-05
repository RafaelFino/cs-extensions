

using Extensions.Utils;

var logger = new Logger();
var ctxFactory = new ContextFactory(logger);

using (var ctx = ctxFactory.Create("Main"))
{
    logger.Info($"Starting main process {Environment.NewLine}");

    for (int i = 0; i < 10; i++)
    {
        logger.Info($"[{i}] Starting iteration");

        using (var ctx1 = ctxFactory.Create("Function1"))
        {
            try
            {
                logger.Info($"[{i}] Doing some work with 100ms delay");
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                ctx1.OnError(ex.Message);
            }
        }

        using (var ctx2 = ctxFactory.Create("Function2"))
        {
            try
            {
                logger.Info($"[{i}] Doing some work with 300ms delay");
                Thread.Sleep(300);
            }
            catch (Exception ex)
            {
                ctx2.OnError(ex.Message);
            }
        }

        logger.Info($"[{i}] Ending iteration{Environment.NewLine}");
    }
}
