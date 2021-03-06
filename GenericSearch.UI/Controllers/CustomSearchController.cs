﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GenericSearch.Core;
using GenericSearch.Data;
using GenericSearch.UI.Models;

namespace GenericSearch.UI.Controllers
{
    public class CustomSearchController : Controller
    {
        private readonly Repository repository;

        public CustomSearchController()
        {
            this.repository = new Repository();
        }

        public ActionResult Index()
        {
            var data = this.repository
                .GetQuery()
                .ToArray();

            var model = new SearchViewModel()
            {
                Data = data,
                SearchCriteria = typeof(GenericSearch.Data.SomeClass)
                    .GetDefaultSearchCriterias()
                    .AddCustomSearchCriteria<GenericSearch.Data.SomeClass>(s => s.Nested.TextNested)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ICollection<AbstractSearch> searchCriteria)
        {
            var data = this.repository
                .GetQuery()
                .ApplySearchCriterias(searchCriteria)
                .ToArray();

            var model = new SearchViewModel()
            {
                Data = data,
                SearchCriteria = searchCriteria
            };

            return View(model);
        }
    }
}