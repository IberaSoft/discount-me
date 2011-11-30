using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace DiscountMe.ViewModels {
    public class MainPageViewModel : NotificationObject {
        private bool showActions;
        private bool isPlaying;

        private ICommand showActionsCommand;
        private ICommand playCommand;
        private ICommand pauseCommand;
        private ICommand shuffleCommand;
        private ICommand repeatCommand;

        public bool ShowActions {
            get { return showActions; }
            set {
                showActions = value;
                RaisePropertyChanged(() => ShowActions);
            }
        }

        public MainPageViewModel() {
            ShowActions = true;
        }

        public ICommand ShowActionsCommand {
            get {
                return showActionsCommand ??
                       (showActionsCommand = new DelegateCommand<bool>(show => ShowActions = show));
            }
        }

        public ICommand PlayCommand {
            get {
                return playCommand ?? (playCommand = new DelegateCommand(() => {
                                                                               isPlaying = true;
                                                                               MessageBox.Show("Playing Music...");
                                                                           }, () => !isPlaying));
            }
        }

        public ICommand PauseCommand {
            get {
                return pauseCommand ?? (pauseCommand = new DelegateCommand(() => {
                                                                                 isPlaying = false;
                                                                                 MessageBox.Show("Music Paused!");
                                                                             }, () => isPlaying));
            }
        }

        public ICommand ShuffleCommand {
            get {
                return shuffleCommand ??
                       (shuffleCommand = new DelegateCommand(() => MessageBox.Show("Shuffle Tracks...")));
            }
        }

        public ICommand RepeatCommand {
            get {
                return repeatCommand ??
                       (repeatCommand = new DelegateCommand(() => MessageBox.Show("Repeat Track...")));
            }
        }
    }
}