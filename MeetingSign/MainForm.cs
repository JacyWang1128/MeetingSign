using MeetingSign.Model;
using MeetingSign.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace MeetingSign
{
    public partial class MainForm : TX.Framework.WindowUI.Forms.MainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //丝滑般流畅
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public static string EncryptWithMD5(string source)
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }
            return strbul.ToString();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.GetWorkingArea(this).Width - this.Size.Width) / 2, (Screen.GetWorkingArea(this).Height - this.Size.Height) / 2);
            using(var db = new MeetingSignModel())
            {
                //var temp = db.Database;
                //db.MeetingRooms.Add(new MeetingRoom() { id = 1});
                //db.SaveChanges();
                if (db.Users.Where(r => r.username == "admin").Count() < 1)
                {
                    db.Users.Add(new User() { id = 0, username = "admin", password = EncryptWithMD5("123456") });
                    db.SaveChanges();
                }
            }
        }
    }
}
