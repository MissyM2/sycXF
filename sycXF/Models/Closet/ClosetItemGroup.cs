using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace sycXF.Models.Closet
{
    public class ClosetItemGroup : ObservableCollection<ClosetItemModel>, INotifyPropertyChanged
    {

        private bool _expanded;

        public string Title { get; set; }

        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Title, ClosetItemCount); }
        }

        public string ShortName { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "dress_1.png" : "icon-Small.png"; }
        }

        public int ClosetItemCount { get; set; }

        public ClosetItemGroup(string title, string shortName, bool expanded = true)
        {
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }

        public static ObservableCollection<ClosetItemGroup> All { private set; get; }

        static ClosetItemGroup()
        {
            ObservableCollection<ClosetItemGroup> Groups = new ObservableCollection<ClosetItemGroup>{
                new ClosetItemGroup("Carbohydrates","C")
                {
                    new ClosetItemModel
                    {
                        Id = 1,
                        PictureUri = "top_1.png",
                        Name = "Floral cap-sleeved blouseM",
                        Description = "Small, Spring, Top M",
                        Size = "Small",
                        Season = "Spring",
                        Type = "Top"
                    },
                    new ClosetItemModel
                    {
                        Id = 2,
                        PictureUri = "bottom_blue_corduroy_skirt_1.png",
                        Name = "Corduroy skirt",
                        Description = "Small, Summer, Bottom M",
                        Size = "Small",
                        Season = "Summer",
                        Type = "Bottom"
                    },
                    new ClosetItemModel
                    {
                        Id = 3,
                        PictureUri = "dress_red_1.png",
                        Name = "Red long dress",
                        Description = "Medium, Winter, Dress M",
                        Size = "Medium",
                        Season = "Winter",
                        Type = "Dress"
                    },
                    new ClosetItemModel
                    {
                        Id = 4,
                        PictureUri = "outerwear_1.png",
                        Name = "London Fog rain coat",
                        Description = "Large, Always, Outerwear M",
                        Size = "Large",
                        Season = "Always",
                        Type = "Outerwear"
                    }
                },
                new ClosetItemGroup("Fruits","F")
                {
                    new ClosetItemModel
                    {
                        Id = 5,
                        PictureUri = "footwear_1.png",
                        Name = "Black leather boots",
                        Description = "Small, Winter, Footwear M",
                        Size = "Small",
                        Season = "Winter",
                        Type = "Footwear"
                    },
                    new ClosetItemModel
                    {
                        Id = 6,
                        PictureUri = "top_white_blouse_1.png",
                        Name = "White dressy blouse",
                        Description = "Medium, Spring, Top M",
                        Size = "Medium",
                        Season = "Spring",
                        Type = "Top"
                    },
                    new ClosetItemModel
                    {
                        Id = 7,
                        PictureUri = "bottoms_1.png",
                        Name = "Blue Corduroy Skirt",
                        Description = "Large, Summer, Bottom M",
                        Size = "Large",
                        Season = "Summer",
                        Type = "Bottom"
                    }
                },
                new ClosetItemGroup("Vegetables","V")
                {
                    new ClosetItemModel
                    {
                        Id = 8,
                        PictureUri = "dress_1.png",
                        Name = "Long Green dress",
                        Description = "Small, Fall, Dress M",
                        Size = "Small",
                        Season = "Fall",
                        Type = "Dress"
                    },
                    new ClosetItemModel
                    {
                        Id = 9,
                        PictureUri = "top_white_sweater_1.png",
                        Name = "White Sweater",
                        Description = "Medium, Always, Outerwear M",
                        Size = "Medium",
                        Season = "Always",
                        Type = "Outerwear"
                    },
                    new ClosetItemModel
                    {
                        Id = 10,
                        PictureUri = "top_white_blouse_1.png",
                        Name = "White Blouse",
                        Description = "Medium, Always, Top M",
                        Size = "Medium",
                        Season = "Always",
                        Type = "Top"
                    },
                    new ClosetItemModel
                    {
                        Id = 10,
                        PictureUri = "accessories_pearl_necklace_1.png",
                        Name = "Pearl Necklace",
                        Description = "Medium, Winter, Accessory M",
                        Size = "Medium",
                        Season = "Winter",
                        Type = "Accessory"
                    }
                },
                new ClosetItemGroup("Dairy","D")
                {
                    new ClosetItemModel
                    {
                        Id = 11,
                        PictureUri = "purse_1.png",
                        Name = "Purse",
                        Description = "Large, Spring, Accessory M",
                        Size = "Large",
                        Season = "Spring",
                        Type = "Accessory"
                    },
                    new ClosetItemModel
                    {
                        Id = 12,
                        PictureUri = "bottoms_1.png",
                        Name = "Jeans",
                        Description = "Small, Winter, Bottom M",
                        Size = "Small",
                        Season = "Winter",
                        Type = "Bottom"
                    },
                    new ClosetItemModel
                    {
                        Id = 12,
                        PictureUri = "bottoms_1.png",
                        Name = "Jeans",
                        Description = "Small, Winter, Bottom M",
                        Size = "Small",
                        Season = "Winter",
                        Type = "Bottom"
                    }
                }
            };
            All = Groups;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
