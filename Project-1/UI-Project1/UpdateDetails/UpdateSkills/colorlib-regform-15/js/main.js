let EmailID = localStorage.getItem("emailid")
EmailID = EmailID.replace(/['‘’"“”]/g, '')
// console.log(EmailID)
const regform = document.getElementById("register-form");

regform.addEventListener("submit", event => {
    event.preventDefault();
});


fetch("https://localhost:7234/Api/TrainerLogin/GetskillbyID?" + new URLSearchParams
    ({
        email: EmailID
    }))
    .then(response => response.json())
    .then(element => {
        const skill = document.getElementById("skill")
        skill.value = element.skill

        const prof = document.getElementById("prof")
        skill2.value = element.profeciencyInSkill

        // const skill3 = document.getElementById("skill3")
        // skill3.value = element.skill_3
    });

async function updateSkill() {
    let skill1 = document.getElementById("skill1").value
    let skill2 = document.getElementById("skill2").value
    let skill3 = document.getElementById("skill3").value

    let val = EmailID.split('@');
    UserID = val[0];

    fetch("https://localhost:7234/Api/TrainerLogin/UpdateSkill?" + new URLSearchParams
        ({
            email: EmailID
        }), {
        method: "PUT",

        body: JSON.stringify({
            userid: UserID,
            skill_1: skill1,
            skill_2: skill2,
            skill_3: skill3
        }),
        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })
        .then((response) => console.log(response))

    alert("Data Updated")
}
