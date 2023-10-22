function deleteAlert(gymId, supplementId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Gyms/ConfirmRemoveSupplementFromGym',
                type: 'POST',
                data: {
                    GymID: gymId,
                    SupplementID: supplementId
                },
                success: function () {
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    );
                    location.reload(); // Reload the page after successful deletion
                },
                error: function () {
                    Swal.fire(
                        'Failed!',
                        'Failed to remove supplement. Please try again.',
                        'error'
                    );
                }
            });
        }
    });
}
