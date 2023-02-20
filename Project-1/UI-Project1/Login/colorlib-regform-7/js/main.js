async function ValidateLogin() {
    const signinform = document.getElementById("login-form");

    signinform.addEventListener("submit", event => {    
        event.preventDefault(); });

    let email = document.getElementById("your_name").value;
    let pass = document.getElementById("your_pass").value;

    await fetch("https://localhost:7079/api/Login/ValidateTrainer?" + new URLSearchParams
    ({
        Email: email,
        Pass: pass
    }), {
        //mode: 'no-cors',
        method: "GET",

        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })

    .then((response) => {
        if (response.status == 200)
        {
            alert("Logged in Sucessfully");
            window.location.href = "../../AddDetails/AddEducation/colorlib-regform-15/index.html";
        }
        else
        {
            alert("Please check the credentails");
        }
    })
    .then((response) => response.json())
    .then(json => console.log(json))
}