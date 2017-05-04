using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveUI;

namespace ReactiveUIWinFormsExample {
    public partial class FrmLogin : Form, IViewFor<LoginViewModel> {
        public FrmLogin() {
            InitializeComponent();

            this.WhenActivated(d => {
                d(this.Bind(ViewModel, x => x.Username, x => x.txtUsername.Text));
                d(this.Bind(ViewModel, x => x.Password, x => x.txtPassword.Text));
                d(this.BindCommand(ViewModel, x => x.LoginCommand, x => x.btnLogin));
            });

            ViewModel = new LoginViewModel();
        }

        public LoginViewModel ViewModel { get; set; }

        object IViewFor.ViewModel {
            get { return ViewModel; }
            set { ViewModel = (LoginViewModel)value; }
        }
    }
}
