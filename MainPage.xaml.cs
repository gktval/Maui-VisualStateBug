namespace VisualStateBug;

public partial class MainPage : ContentPage {

    private string _surveyState;
    private string _pauseState;
    private string _startButtonText;
    private string _pauseButtonText;
    private bool _isSurveying;
    private bool _isPaused;
    public Command StartStopCommand { get; set; }
    public Command PauseResumeCommand { get; set; }
    public GridLength Button1Width { get; set; }
    public GridLength Button2Width { get; set; }

    public string StartButtonText {
        get { return _startButtonText; }
        set { _startButtonText = value; OnPropertyChanged(nameof(StartButtonText)); }
    }
    public string PauseButtonText {
        get { return _pauseButtonText; }
        set { _pauseButtonText = value; OnPropertyChanged(nameof(PauseButtonText)); }
    }

    public string SurveyState {
        get { return _surveyState; }
        set { _surveyState = value; OnPropertyChanged(nameof(SurveyState)); }
    }

    public string PauseState {
        get { return _pauseState; }
        set { _pauseState = value; OnPropertyChanged(nameof(PauseState)); }
    }

    public MainPage() {
        InitializeComponent();

        SurveyState = "CanStart";
        PauseState = "Disabled";
        StartButtonText = "Start";
        PauseButtonText = "Pause";
        Button1Width = new GridLength(0, GridUnitType.Absolute);
        Button2Width = GridLength.Star;

        StartStopCommand = new Command(OnStartStop);
        PauseResumeCommand = new Command(OnPauseResume);

        BindingContext = this;
    }

    private void OnStartStop(object obj) {

        if (_isSurveying) // stopping the survey
        {
            _isSurveying = false;
            SurveyState = "CanStart";
            PauseState = "Disabled";
            StartButtonText = "Start";
            PauseButtonText = "Pause";
            Button1Width = new GridLength(0, GridUnitType.Absolute);
            Button2Width = GridLength.Star;
        }
        else //starting the survey
        {
            _isSurveying = true;
            SurveyState = "CanStop";
            PauseState = "CanPause";
            StartButtonText = "Stop";
            Button1Width = GridLength.Star;
            Button2Width = GridLength.Star;
        }

        OnPropertyChanged(nameof(Button1Width));
        OnPropertyChanged(nameof(Button2Width));
    }

    private void OnPauseResume(object obj) {
        if (_isPaused) // resuming
        {
            _isSurveying = true;
            _isPaused = false;
            PauseState = "CanPause";
            PauseButtonText = "Pause";
            SurveyState = "CanStop";
            Button1Width = GridLength.Star;
            Button2Width = GridLength.Star;
        }
        else //pausing surveying
        {
            _isSurveying = false;
            _isPaused = true;
            PauseState = "CanStart";
            PauseButtonText = "Resume";
            SurveyState = "Disabled";
            Button1Width = GridLength.Star;
            Button2Width = new GridLength(0, GridUnitType.Absolute);
        }

        OnPropertyChanged(nameof(Button1Width));
        OnPropertyChanged(nameof(Button2Width));
    }
}

