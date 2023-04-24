using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace m10sensors.ViewModels
{
    internal class LocationViewModel : INotifyPropertyChanged
    {
        private double? _latitude;
        private double? _longitude;
        private double? _altitude;
        private string _status;
        private bool _isWorking;

        public LocationViewModel()
        {
            Status = "Nic";
            ReadCachedCommand = new Command(
                async () =>
                {
                    try
                    {
                        Status = "Pracuji";
                        Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                        if (location != null)
                        {
                            Latitude = location.Latitude;
                            Longitude = location.Longitude;
                            Altitude = location.Altitude;
                        }
                        Status = "Hotovo";
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        Status = "Geolokace není podporována.";
                    }
                    catch (FeatureNotEnabledException fneEx)
                    {
                        Status = "Geolokace není zapnuta.";
                    }
                    catch (PermissionException pEx)
                    {
                        Status = "Nedostateční práva.";
                    }
                    catch (Exception ex)
                    {
                        Status = "Chyba: " + ex.Message;
                    }
                }
                );
            ReadCommand = new Command(
                async () =>
                {
                    try
                    {
                        Status = "Pracuji";
                        CancellationTokenSource _cancel;
                        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                        _cancel = new CancellationTokenSource();

                        Location location = await Geolocation.Default.GetLocationAsync(request, _cancel.Token);

                        if (location != null)
                        {
                            Latitude = location.Latitude;
                            Longitude = location.Longitude;
                            Altitude = location.Altitude;
                        }
                        Status = "Hotovo";
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        Status = "Geolokace není podporována.";
                    }
                    catch (FeatureNotEnabledException fneEx)
                    {
                        Status = "Geolokace není zapnuta.";
                    }
                    catch (PermissionException pEx)
                    {
                        Status = "Nedostateční práva.";
                    }
                    catch (Exception ex)
                    {
                        Status = "Chyba: " + ex.Message;
                    }
                }
                );

        }

        public double? Latitude { 
            get { 
                return _latitude; 
            }
            set {
                _latitude = value;
                OnPropertyChanged();
            } 
        }

        public double? Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        public double? Altitude
        {
            get
            {
                return _altitude;
            }
            set
            {
                _altitude = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public Command ReadCachedCommand { get; private set; }
        public Command ReadCommand { get; private set; }
        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
