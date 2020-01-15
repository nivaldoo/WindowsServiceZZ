using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsService1.Programa;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Timer timer = new Timer(new TimerCallback(timer_Tick), null, 0, 60000);
            }
            catch (Exception ex)
            {
                using (StreamWriter streamWriter = new StreamWriter("C:/LogService/Teste.txt", true))
                {
                    streamWriter.WriteLine("3rrou -> {0} {1}", DateTime.Now.ToString("HH:mm:ss"), ex.Message);
                }
            }
        }

        public void timer_Tick(object sender)
        {
            //Class1.CriarArquivo();
            //Class1.EnviarEmail();
            Class1.AtualizaAPI();
        }

        protected override void OnStop()
        {
        }
    }
}
