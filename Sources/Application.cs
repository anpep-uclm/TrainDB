using System;

namespace TrainDB {
    /// <summary>
    ///     Contains the entry point for the application
    /// </summary>
    public static class Application {
        /// <summary>
        ///     Defines the entry point for the application
        /// </summary>
        /// <returns>An exit code to the operating system</returns>
        [STAThread]
        public static int Main() {
#if TEST
            var broker = DatabaseBroker.GetInstance("C:\\Users\\Angel\\Documents\\trains.db");
            broker.OpenConnection();

            foreach (var row in broker.ExecuteQuery("SELECT * FROM TrainTypes")) {
                foreach (var column in row.AllKeys) {
                    var value = row[column];
                    Console.WriteLine($"{column}: {value}");
                }

                Console.WriteLine();
            }
            return 0;
#endif

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainWindow());
            return 0;
        }
    }
}
