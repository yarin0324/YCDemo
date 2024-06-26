﻿using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private new const string Url = @"http://localhost:5095/app/employee";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        /// <summary>
        /// 建立一筆員工資料
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public ActionResult CreateEmployee(Employee employeeInfo)
        {
            if (string.IsNullOrWhiteSpace(employeeInfo.IdentityNo) || string.IsNullOrWhiteSpace(employeeInfo.Name))
            {
                return Json(new ResponseResult(false, "參數檢核失敗!"));
            }

            var client = new RestClient(Url);
            var request = new RestRequest(Url);
            
            request.AddParameter(nameof(employeeInfo.IdentityNo), employeeInfo.IdentityNo);
            request.AddParameter(nameof(employeeInfo.Name), employeeInfo.Name);

            var response = client.Execute(request, Method.Post);
            var content = JsonConvert.DeserializeObject<ApiResponseContent>(response.Content);

            return content.ErrorCode == 0 ? 
                Json(new ResponseResult(true, "人員資料新增成功!")) : 
                Json(new ResponseResult(false, "人員資料新增失敗!"));
        }

        /// <summary>
        /// 讀取員工資料
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public ActionResult ReadEmployee(Employee employeeInfo)
        {
            if (string.IsNullOrWhiteSpace(employeeInfo.IdentityNo))
            {
                return Json(new ResponseResult(false, "參數檢核失敗!"));
            }

            var client = new RestClient(Url);
            var request = new RestRequest(Url);

            request.AddParameter(nameof(employeeInfo.IdentityNo), employeeInfo.IdentityNo);

            var response = client.Execute(request, Method.Get);
            var content = JsonConvert.DeserializeObject<ApiResponseContent>(response.Content);

            return content.ErrorCode == 0 ?
                Json(new ResponseResult(true, "人員資料讀取成功!", content.Data)) :
                Json(new ResponseResult(false, "人員資料讀取失敗!"));
        }

        /// <summary>
        /// 更新一筆員工資料
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public ActionResult UpdateEmployee(Employee employeeInfo)
        {
            if (string.IsNullOrWhiteSpace(employeeInfo.IdentityNo) || string.IsNullOrWhiteSpace(employeeInfo.Name))
            {
                return Json(new ResponseResult(false, "參數檢核失敗!"));
            }

            var client = new RestClient(Url);
            var request = new RestRequest(Url);

            request.AddParameter(nameof(employeeInfo.IdentityNo), employeeInfo.IdentityNo);
            request.AddParameter(nameof(employeeInfo.Name), employeeInfo.Name);

            var response = client.Execute(request, Method.Put);
            var content = JsonConvert.DeserializeObject<ApiResponseContent>(response.Content);

            return content.ErrorCode == 0 ?
                Json(new ResponseResult(true, "人員資料修改成功!")) :
                Json(new ResponseResult(false, "人員資料修改失敗!"));
        }

        /// <summary>
        /// 刪除一筆員工資料
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public ActionResult DeleteEmployee(Employee employeeInfo)
        {
            if (string.IsNullOrWhiteSpace(employeeInfo.IdentityNo))
            {
                return Json(new ResponseResult(false, "參數檢核失敗!"));
            }

            var client = new RestClient(Url);
            var request = new RestRequest(Url);

            request.AddParameter(nameof(employeeInfo.IdentityNo), employeeInfo.IdentityNo);

            var response = client.Execute(request, Method.Delete);
            var content = JsonConvert.DeserializeObject<ApiResponseContent>(response.Content);

            return content.ErrorCode == 0 ?
                Json(new ResponseResult(true, "人員資料刪除成功!")) :
                Json(new ResponseResult(false, "人員資料刪除失敗!"));
        }
    }
}
