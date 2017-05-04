using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;

namespace ReactiveUIWinFormsExample {
    public class LoginViewModel : ReactiveObject {
        public LoginViewModel() {
            var canExecute = this.WhenAnyValue(vm => vm.Username, vm => vm.Password)
                .Select(x => !string.IsNullOrWhiteSpace(x.Item1) && !string.IsNullOrWhiteSpace(x.Item2));

            LoginCommand = ReactiveCommand.Create(Login, canExecute);
        }

        private string _username;
        private string _password;

        public string Username {
            get { return _username; }
            set { this.RaiseAndSetIfChanged(ref _username, value); }
        }

        public string Password {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        public ReactiveCommand LoginCommand { get; private set; }

        private void Login() {
            //Login
        }

    }
}
