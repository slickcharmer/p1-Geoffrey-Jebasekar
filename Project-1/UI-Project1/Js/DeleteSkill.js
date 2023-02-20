let EmailID = localStorage.getItem("emailid");
EmailID = EmailID.replace(/['‘’"“”]/g, '');

// var skill_1;
// var prof;
//Skill = Skill.replace(/['‘’"“”]/g, '');

           // function GetSkill() {
				
                // let email = document.getElementById("email").value;
				// console.log(email);
                // let id;
				// let skills;
				// let prof;
                // Make an API request to get education details
                fetch("https://localhost:7079/api/Skills/GetTrainersSkills?" + new URLSearchParams
                ({

                    email : EmailID,
					

    
                })).then(response => response.json())
				.then(data => {
					// Display education details in the page
					const educationDetailsElement = document.getElementById('skill_details');
					data.forEach(skill => {
						const educationElement = document.createElement('div');
						educationElement.classList.add('row');
						// <div class = "label">Welcome</div>;
						// <div class="value">${skill.emailid}</div>;
						educationElement.innerHTML = `
							<div class="label">Skill name:</div>
							<div class="value">${skill.skill}</div>
							<div class="label">Profeciency in skill:</div>
							<div class="value">${skill.profeciencyInSkill}</div>
							
						`;
						educationDetailsElement.appendChild(educationElement);
					});
				})
				.catch(error => {
					console.error(error);
					alert('An error occurred while loading education details.');
				});

                // .then((res) => console.log(res))
                async function GetSkill() 
				{
					let skill = document.getElementById("skill").value;
					localStorage.setItem("Skill",skill);
					fetch("https://localhost:7079/api/Skills/GetTrainersSkillsBySkill?" + new URLSearchParams
                ({

                    email : EmailID,
					skill : skill,
					

    
                }))
				.then((response) => {
					if (response.status == 200)
					{
						// localStorage.setItem("emailid",email);
						// alert("Logged in Sucessfully");
						return response.json();
						
						
						
						//window.location.href = "../../TrainerMenu/TrainerMenu.html";
					}
					else
					{
						alert("Please check the credentails");
					}
				}).then(data => {
					console.log(data);
					console.log(data[0].skill); 
					const markup=`
					<!-- <div class="form-row"> -->
					<div class="container">
					<h2>Update your skills here</h2>
						<div class="form-group">
							<label for="comp_name">Skill name :</label>
							<input type="text"  value="${data[0].skill}" name="name" id="skill__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">prof name :</label>
							<input type="text" value="${data[0].profeciencyInSkill}"name="name" id="profeciency" required/>
						</div>
						<button type="submit" onclick="updateSkill()">Update</button>
					</div>	
					<!-- </div> -->
				   
					`;
					document.querySelector('.container').insertAdjacentHTML("afterend",markup);
				})


					
				}  
				// async function updateSkill() {
				// 	let Skill_1 = localStorage.getItem("Skill");
				// 	let skill_ = document.getElementById("skill__").value
				// 	let prof_ = document.getElementById("profeciency").value
				// 	//let skill3 = document.getElementById("skill3").value
				
				// 	// let val = EmailID.split('@');
				// 	// UserID = val[0];
				//     console.log(skill_);
				// 	console.log(prof_);
				// 	console.log(Skill_1);
				// 	fetch("https://localhost:7079/api/Skills/UpdateTrainersSkills?" + new URLSearchParams
				// 		({
				// 			email: EmailID,
				// 			skill: Skill_1,
							
				// 		}), {
							
				// 		method: "PUT",
				
				// 		body: JSON.stringify({
				// 			emailid: "string",
				// 			skill: skill_,
				// 			profeciencyInSkill: prof_,
				// 			//skill_3: skill3
				// 		}),
				// 		headers: {
				// 			"Content-type": "application/json; charset=UTF-8",
				// 		}
				// 	})
				// 		.then((response) => console.log(response))
				
				// 	alert("Data Updated")
				// }			
                
                function DeleteSkill() {
                    let skill = document.getElementById("skill").value;
					localStorage.setItem("Skill",skill);
                    let Skill_1 = localStorage.getItem("Skill");

					// var companyName = prompt("Enter the company name");
					// var choice = confirm("Are you sure?");
					// let Skill_1 = localStorage.getItem("Skill");
					// let skill_ = document.getElementById("skill__").value
					// let prof_ = document.getElementById("profeciency").value
				
					// if(choice){
					// 	   let options = {
					// 		method: "DELETE"
					// 	}; 
					// 	https://localhost:7079/api/Skills/DeleteTrainerSkills?email=geffshelby%40gmail.com&skill=C

					// 	   fetch(`https://localhost:44329/Company/delete?company=${companyName.trim()}&email=${localStorage.getItem('LoginEmail')}`, options)
					// 	.then((response) => {
					// 		if (response.ok) {
					// 		   window.location.href = "DeleteSkillDetails.html";
					// 		}
				
					// 	});
					// }
                    console.log(skill);
                    fetch("https://localhost:7079/api/Skills/DeleteTrainerSkills?" + new URLSearchParams
                    ({
                        email : EmailID,
                        skill : Skill_1,

                    }),
                    {
                        method: "DELETE",
                        
                    }).then((response)=>{
                        if (response.ok) {
                            		   window.location.href = "DeleteSkillDetails.html";
                            		}
                        
                    })
                   
				}