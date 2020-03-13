using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Anubis.Architecture;
using Anubis.Models;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;
using static Anubis.Architecture.ClassHelper;

namespace AnubisDataImport
{
    public partial class MainWindow : MaterialForm
    {
        // Changes the amount of rows to import at once to the DB
        private int _batchImportCount = 1000;

        // Change this to 'true' to use the new Bulk Copy functionality
        private bool _useBulkCopyMethod = false;

        private List<GameData> _allGameData;
        private int _totalGames;

        private Stopwatch _stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();

            LoadFormColourScheme();
        }

        private void LoadFormColourScheme()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.Light;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Teal700, TextShade.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetControlsVisibility(false);

            SetFormFontOptions();

            materialProgressBar.Style = ProgressBarStyle.Marquee;
            materialProgressBar.MarqueeAnimationSpeed = 100;
        }

        private void SetFormFontOptions()
        {
            // Overrides the default Font style on form
            // Bug: Form reverts to original Font if not set programmatically
            Font = new Font("Segoe UI", Font.Size);
            btnSaveToDB.Font = new Font("Segoe UI", btnSaveToDB.Font.Size);
            lblHeader.Font = new Font("Segoe UI", lblHeader.Font.Size);
            lblMessage.Font = new Font("Segoe UI", lblHeader.Font.Size);
            lblTimer.Font = new Font("Segoe UI", lblHeader.Font.Size);
            lblCount.Font = new Font("Segoe UI", lblHeader.Font.Size);
        }

        private void SetControlsVisibility(bool visible)
        {
            SafeBeginInvoke(lblCount, () =>
            {
                lblCount.Visible = visible;
                lblCount.Text = "";
            });

            SafeBeginInvoke(lblMessage, () =>
            {
                lblMessage.Visible = visible;
                lblMessage.Text = "";
            });

            SafeBeginInvoke(lblTimer, () =>
            {
                lblTimer.Visible = visible;
                lblTimer.Text = "";
            });

            //SafeBeginInvoke(materialProgressBar, () =>
            //{
            //    materialProgressBar.Visible = visible;
            //});
        }

        private void btnSaveToDB_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveToDB.Enabled = false;

                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Steam games data import failed to import!";
                lblMessage.Visible = true;

                MessageBox.Show("Steam games data import failed for the following reason:\n" + ex.Message, "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSaveToDB.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SafeBeginInvoke(materialProgressBar, () =>
            {
                materialProgressBar.Visible = true;
            });

            _stopwatch.Reset();
            _stopwatch.Start();

            _allGameData = SteamHelper.GetAllSteamGames();
                
            _totalGames = _allGameData.Count;

            if (_useBulkCopyMethod)
                SteamHelper.BulkCopySteamGamesToDatabase(_allGameData);
            else
                BulkInsertSteamGames();

            _stopwatch.Stop();
        }

        private void BulkInsertSteamGames()
        {
            SafeBeginInvoke(progressBar, () => { progressBar.Maximum = _totalGames; });
            SafeBeginInvoke(lblCount, () =>
            {
                lblCount.Text = $"Games Imported: {0} of {_totalGames}";
                lblCount.Visible = true;
            });

            int counter = 0;
            List<GameData> gameList = new List<GameData>();

            foreach (GameData gameData in _allGameData)
            {
                if (backgroundWorker.CancellationPending) return;

                counter++;

                gameList.Add(gameData);
                if (gameList.Count != _batchImportCount && counter != _totalGames) continue;

                SteamHelper.ImportSteamGames(gameList, _totalGames, counter);

                SafeBeginInvoke(lblCount, () => { lblCount.Text = $"Games Imported: {counter} of {_totalGames}"; });

                backgroundWorker.ReportProgress(counter);
                gameList = new List<GameData>();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblMessage.Text = "Steam games data import was successful!";
            lblMessage.Visible = true;

            lblTimer.Text = $"Completed in: {_stopwatch.Elapsed.Seconds} seconds";
            lblTimer.Visible = true;

            materialProgressBar.Visible = false;
        }
    }
}
