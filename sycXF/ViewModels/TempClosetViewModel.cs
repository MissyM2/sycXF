using System;
using System.Collections.ObjectModel;
using sycXF.Models.Closet;

namespace sycXF.ViewModels
{
    public class TempClosetViewModel
    {
        public TempClosetViewModel()
        {
        }

        public ObservableCollection<Agenda> MyAgenda { get => GetAgenda(); }

        private ObservableCollection<Agenda> GetAgenda()
        {
            return new ObservableCollection<Agenda>
            {
                new Agenda
                {
                    Color = "#B96CBD",
                    CategoryType = "Season",
                    CategoryName = "Winter",
                    CategoryTitle = "Winter",
                    IconGlyph = "noun-snowflake-2098252.png",
                    IconFamily = "FontAwesome-Regular",
                    PictureUri = "noun-shirt-3013538.png",
                    ClosetItems = new ObservableCollection<ClosetItemModel>
                    {
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
                            Id = 10,
                            PictureUri = "accessories_pearl_necklace_1.png",
                            Name = "Pearl Necklace",
                            Description = "Medium, Winter, Accessory M",
                            Size = "Medium",
                            Season = "Winter",
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
                        }
                    }
                },

                new Agenda
                {
                    Color = "#B96CBD",
                    CategoryType = "Season",
                    CategoryName = "Spring",
                    CategoryTitle = "Spring",
                    IconGlyph = "noun-sunny-2494509.png",
                    IconFamily = "FontAwesome-Regular",
                    PictureUri = "noun-shirt-3013538.png",
                    ClosetItems = new ObservableCollection<ClosetItemModel>
                    {
                        new ClosetItemModel { Name = "Maddy Leger", Description = "07:30", Season="Winter" },
                        new ClosetItemModel { Name = "David Ortinau", Description = "08:30", Season="Winter" },
                        new ClosetItemModel { Name = "Gerald Versluis", Description = "10:30", Season="Winter" }
                    }
                },

                new Agenda
                {
                    Color = "#B96CBD",
                    CategoryType = "Season",
                    CategoryName = "Summer",
                    CategoryTitle = "Summer",
                    IconGlyph = "noun-sun-2494511.png",
                    IconFamily = "FontAwesome-Regular",
                    PictureUri = "noun-shirt-3013538.png",
                    ClosetItems = new ObservableCollection<ClosetItemModel>{
                        new ClosetItemModel { Name = "Maddy Leger", Description = "07:30", Season="Winter" },
                        new ClosetItemModel { Name = "David Ortinau", Description = "08:30", Season="Winter" },
                        new ClosetItemModel { Name = "Gerald Versluis", Description = "10:30", Season="Winter"
                        }
                    }
                },

                new Agenda
                {
                    Color = "#B96CBD",
                    CategoryType = "Season",
                    CategoryName = "Fall",
                    CategoryTitle = "Fall",
                    IconGlyph = "noun-autumn-3789702.png",
                    IconFamily = "FontAwesome-Regular",
                    PictureUri = "noun-shirt-3013538.png",
                    ClosetItems = new ObservableCollection<ClosetItemModel>
                    {
                        new ClosetItemModel { Name = "Maddy Leger", Description = "07:30", Season="Winter" },
                        new ClosetItemModel { Name = "David Ortinau", Description = "08:30", Season="Winter" },
                        new ClosetItemModel { Name = "Gerald Versluis", Description = "10:30", Season="Winter" }
                    }
                },

                new Agenda
                {
                    Color = "#B96CBD",
                    CategoryType = "Season",
                    CategoryName = "Always",
                    CategoryTitle = "Always",
                    IconGlyph = "noun-dress-3013536.png",
                    IconFamily = "FontAwesome-Regular",
                    PictureUri = "noun-shirt-3013538.png",
                    ClosetItems = new ObservableCollection<ClosetItemModel>
                    {
                        new ClosetItemModel { Name = "Maddy Leger", Description = "07:30", Season="Winter" },
                        new ClosetItemModel { Name = "David Ortinau", Description = "08:30", Season="Winter" },
                        new ClosetItemModel { Name = "Gerald Versluis", Description = "10:30", Season="Winter" }
                    }
                },

                new Agenda
                {
                    Color = "#B96CBD",
                    CategoryType = "Type",
                    CategoryName = "Top",
                    CategoryTitle = "Tops",
                    IconGlyph = "noun-shirt-3013538.png",
                    IconFamily = "FontAwesome-Regular",
                    PictureUri = "noun-shirt-3013538.png",
                    ClosetItems = new ObservableCollection<ClosetItemModel>
                    {
                        new ClosetItemModel { Name = "Maddy Leger", Description = "07:30", Season="Winter" },
                        new ClosetItemModel { Name = "David Ortinau", Description = "08:30", Season="Winter" },
                        new ClosetItemModel { Name = "Gerald Versluis", Description = "10:30", Season="Winter" }
                    }
                }
            };
        }
    }
}

