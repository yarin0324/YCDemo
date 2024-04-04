function createEmployee() {
    $.ajax({
        type: "POST",
        url: createEmployeeUrl,
        dataType: "json",
        data: {
            employeeInfo: {
                IdentityNo: 'asd',
                Name: 'XXX'
            }
        },
        success: function (response) {
        },
        error: function (thrownError) {
            console.log(thrownError);
        }
    });
}

function readEmployee() {
    $.ajax({
        type: "POST",
        url: readEmployeeUrl,
        dataType: "json",
        data: {
            employeeInfo: {
                IdentityNo: 'asd'
            }
        },
        success: function (response) {
            console.log(response);
        },
        error: function (thrownError) {
            console.log(thrownError);
        }
    });
}

function updateEmployee() {
    $.ajax({
        type: "POST",
        url: readEmployeeUrl,
        dataType: "json",
        data: {
            employeeInfo: {
                IdentityNo: 'asd',
                Name: 'xxx'
            }
        },
        success: function (response) {
            console.log(response);
        },
        error: function (thrownError) {
            console.log(thrownError);
        }
    });
}

function deleteEmployee() {
    $.ajax({
        type: "POST",
        url: readEmployeeUrl,
        dataType: "json",
        data: {
            employeeInfo: {
                IdentityNo: 'asd'
            }
        },
        success: function (response) {
            console.log(response);
        },
        error: function (thrownError) {
            console.log(thrownError);
        }
    });
}

document.addEventListener("DOMContentLoaded", function (event) {
    createEmployee();
});