import Swal from 'sweetalert2'

window.Swal = Swal;

window.EliminarTipoCuenta = async function (id)
{
    const result = await Swal.fire({
        title: "¿Desea eliminar el tipo cuenta?",
        text: "",
        icon: "error",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Aceptar"
    });

    if (!result.isConfirmed) {
        return;
    }
    try {
        const response =  await fetch(`/TiposCuentas/Eliminar?tipoCuentaId=${id}`, {
            method: "POST",
        });

        if (response.redirected) {
            window.location.href = response.url;
            return;
        }
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

window.EliminarCuenta = async function(id){
    const result = await Swal.fire({
        title: "¿Desea eliminar la cuenta?",
        text: "",
        icon: "error",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Aceptar"
    });
    if (!result.isConfirmed) {
        return;
    }

    try {

        const response = await fetch(`/Cuentas/Borrar?id=${id}`, {
            method: "POST"
        });

        if (!response.ok) {
            throw new Error("No se pudo eliminar la cuenta");
        }

        if (response.redirected) {
            window.location.href = response.url;
            return;
        }

        window.location.href = "/Cuentas/Index";

    } catch (error) {

        Swal.fire({
            title: "Error",
            text: error.message,
            icon: "error",
            confirmButtonText: "Aceptar"
        });

    }
}