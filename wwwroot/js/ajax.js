
/*< !--
    Author: Alejandro Serrano
Partner: None
Date: 10 / 11 / 2021
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

    I, Alejandro Serrano, certify that I edited this code from what was provided by scaffolding and did not copy it in part or whole from
another source.Any references used in the completion of the assignment are cited in my README file.

File Contents:

The current file contains a function that connects to the Admin cshtml in order to change the roles of users. 

Update for PS6:
Date: 10 / 25 / 2021
Added function that allows admin to change notes for course model. 
-->*/

/**
 * Changes the role of user. Only admin can perfom this action
 * @param {any} userid id of the user
 * @param {any} role role to be changed to
 * @param {any} enable_disable always true. This needs to be removed
 */
function change_selected_role(userid, role, enable_disable) {
    

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes change role'
    }).then((result) => {
        if (result.isConfirmed) {

            var data =
            {
                userid: userid,
                role: role,
                enable_disable: enable_disable
            };
            var url = "/Home/ChangeRole";

            $.post(url, data)
                .fail(function () {
                    console.log("oops");
                })
                .done(function (result) {
                    console.log("role changed");
                }).always(function () {
                    console.log("always");
                });

            Swal.fire(
                'Changed',
                'The roles have been updated',
                'success'
            )
        }
    })
};

/**
 * Changes the note for each course. Can only be accessed by admin
 * @param {any} note note to add to model
 * @param {any} course_id id of the course to change
 */
function submit_note(note, course_id)
{

    var url = "/Courses/SubmitNote";
    var data =
    {
        note: note,
        course_id : course_id
    };
    $.post(url, data)
        .fail(function () {
            console.log("oops");
        })
        .done(function (result) {
            console.log("role changed");
        }).always(function () {
            console.log("always");
        });
    
}
