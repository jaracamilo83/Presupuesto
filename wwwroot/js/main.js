import Swal from 'sweetalert2'

window.Swal = Swal;

window.EliminarTipoCuenta =  function (id)
{
    const result = Swal.fire({
        title: "¿Desea eliminar el tipo cuenta?",
        text: "",
        icon: "error",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Aceptar"
    }).then((result) => {
        if (result.isConfirmed) {
            try {
                const response =  fetch(`/TiposCuentas/Eliminar?tipoCuentaId=${id}`, {
                    method: "POST",
                });

                if (response.redirected) {
                    window.location.href = response.url;
                    return;
                }
                console.log(response);
                if (!response) {
                    throw new Error("No se pudo eliminar el tipo cuenta");
                }

                window.location.href = "/TipoCuentas";
            } catch (error) {
                Swal.fire({
                    title: "Error",
                    text: error.message,
                    icon: "error",
                    confirmButtonText: "Aceptar"
                });
            }
        }
    });
}