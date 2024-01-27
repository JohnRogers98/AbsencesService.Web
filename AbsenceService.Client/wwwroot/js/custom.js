$(document).ready(
    () => {
        GetAbsencesData();
        GetEmployeesData();
    }
);

function GetAbsencesData() {
    $.ajax({
        type: "GET",
        url: "/Index?handler=AbsencesList",
        contentType: "application/json",
        dataType: "json",
        success: function (result, status, xhr) {

            var tableBody = "";
            $.each(
                result,
                function (index, item)
                {
                    tableBody += "<tr>";
                    tableBody += "<td>" + item.id + "</td>";
                    tableBody += "<td>" + item.employee.id + "</td>";
                    tableBody += "<td>" + item.reason + "</td>";
                    tableBody += "<td>" + item.startDate + "</td>";
                    tableBody += "<td>" + item.duration + "</td>";
                    tableBody += "<td>" + item.discounted + "</td>";
                    tableBody += "<td>" + item.description + "</td>";
                    tableBody += "<td>" + '<a href="#" class="btn btn-warning" onclick="ShowUpdateAbsenceModal(' + item.id + ')">Изменить</a> | <a href="#" class="btn btn-danger" onclick="DeleteAbsence(' + item.id + ')">Удалить</a>' + "</td>";
                    tableBody += "</tr>";
                }
            );
            $("#table_absences").html(tableBody);
        },
        failure: function (response) {
            alert('Ошибка загрузки');
        }
    });
};

function GetEmployeesData() {
    $.ajax({
        type: "GET",
        url: "/Index?handler=EmployeesList",
        contentType: "application/json",
        dataType: "json",
        success: function (result, status, xhr) {

            var selectBody = "";
            $.each(
                result,
                function (index, item) {
                    selectBody += '<option value="' + item.id + '">' + item.lastName + '</option>';
                }
            );
            $("#absenceEmployee").html(selectBody);
        },
        failure: function (response) {
            alert('Ошибка загрузки');
        }
    });
};

$("#modal_addAbsence").addEventListener('shown.bs.modal', () => {
    $("#btn_addAbsenceModal").focus();
});

function AddAbsence() {
    var absence = {
        employeeId: $("#absenceEmployee").val(),
        reason : $("#absenceReason").val(),
        startDate : $("#absenceStartDate").val(),
        duration : $("#absenceDuration").val(),
        discounted: document.getElementById("absenceDiscounted").checked,
        description : $("#absenceDescription").val()
    };

    $.ajax({
        type: "POST",
        url: "/Index?handler=absence",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: absence,
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        dataType: "json",
        success: function () {
            alert("Отсутствие добавлено");
            GetAbsencesData();
        },
        failure: function () {
            alert("Ошибка добавления");
        }
    });
};

function DeleteAbsence(id) {
    $.ajax({
        type: "POST",
        url: "/Index?handler=DeleteAbsence",
        data: { id : id},
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        success: function () {
            alert("Удалено");
            GetAbsencesData();
        },
        failure: function () {
            alert("Ошибка удаления");
        }
    });
}

function ShowUpdateAbsenceModal(id) {
    var table = document.getElementById("table_absences");
    for (var i = 0, row; row = table.rows[i]; i++) {
        if (row.cells[0].innerText == id) {

            var absence = {
                id: row.cells[0].innerText,
                employeeId: row.cells[1].innerText,
                reason: row.cells[2].innerText,
                startDate: row.cells[3].innerText,
                duration: row.cells[4].innerText,
                discounted: row.cells[5].innerText === "true",
                description: row.cells[6].innerText
            };

            $("#modal_updateAbsence").modal('show');
            $("#upd_absenceId").val(absence.id);
            $("#upd_absenceEmployee").val(absence.employeeId);
            $("#upd_absenceReason").val(absence.reason);
            $("#upd_absenceStartDate").val(absence.startDate);
            $("#upd_absenceDuration").val(absence.duration);
            $("#upd_absenceDiscounted").prop('checked', absence.discounted);
            $("#upd_absenceDescription").val(absence.description);

            break;
        }
    }
}

function UpdateAbsence() {
    var absence = {
        id: $("#upd_absenceId").val(),
        reason: $("#upd_absenceReason").val(),
        startDate: $("#upd_absenceStartDate").val(),
        duration: $("#upd_absenceDuration").val(),
        discounted: $("#upd_absenceDiscounted").prop("checked"),
        description: $("#upd_absenceDescription").val()
    }

    $.ajax({
        type: "PUT",
        url: "/Index?handler=absence",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: absence,
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        dataType: "json",
        success: function () {
            alert("Отсутствие изменено");
            GetAbsencesData();
        },
        failure: function () {
            alert("Ошибка изменения");
        }
    });
}