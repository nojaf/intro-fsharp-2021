using System;
using System.IO;


/*
 * The inputs have known constraints, it can go from [-2147483647, 2147483647]
 * All expressions are pure so the outcome is deterministic.
 */

public int Add(int x, int y)
{
    return x + y;
}

var logFile = Path.Combine(System.IO.Path.GetTempPath(), "math-log.txt");
var logger = new System.IO.StreamWriter(logFile, true);

/*
 * logger.WriteLine is considered a side effect.
 * It acts as an external component which makes the result of the function not predictable
 * logger.WriteLine might throw an exception for all we know
 */

public int AddWithLogging(int x, int y)
{
    logger.WriteLine($"Calculating {x} + {y}");
    return x + y;
}

/*
 * From certain point of view this function is pure again.
 * No external factor is in play, result is determined purely by the inputs
 *
 * Note that this is a higher order function.
 * And we moved the actual problem to the caller of this function.
 * Returning void also indicates a side-effect
 */

public int Add(Action<string> logger, int x, int y)
{
    logger("Calculation of {x} and {y}");
    return x + y;
}

// Execute some code

AddWithLogging(17,2);
logger.Dispose();
Console.WriteLine($"Wrote logs to {logFile}");