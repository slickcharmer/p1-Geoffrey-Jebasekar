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
                fetch("https://localhost:7079/api/Experience/GetTrainersExperience?" + new URLSearchParams
                ({

                    email : EmailID,
					

    
                })).then(response => response.json())
				.then(data => {
					// Display education details in the page
					const educationDetailsElement = document.getElementById('exp_details');
					data.forEach(exp => {
						const educationElement = document.createElement('div');
						educationElement.classList.add('row');
						// <div class = "label">Welcome</div>;
						// <div class="value">${skill.emailid}</div>;
						educationElement.innerHTML = `
							<div class="label">Company Name:</div>
							<div class="value">${exp.companyName}</div>
							<div class="label">Title:</div>
							<div class="value">${exp.title}</div>
							<div class="label">Experience in Years:</div>
							<div class="value">${exp.experience}</div>
							<div class="label">Location:</div>
							<div class="value">${exp.location}</div>
							
							
						`;
						educationDetailsElement.appendChild(educationElement);
					});
				})
				.catch(error => {
					console.error(error);
					alert('An error occurred while loading experience details.');
				});

                // .then((res) => console.log(res))
                async function GetExp() 
				{
					let exp = document.getElementById("_exp").value;
                    let title = document.getElementById("_title").value;
					localStorage.setItem("_Exp_",exp);
                    localStorage.setItem("_Title_",title);
					fetch("https://localhost:7079/api/Experience/GetTrainersExperienceByExp?" + new URLSearchParams
                ({

                    email : EmailID,
					exp : exp,
                    title : title,
					

    
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
					//console.log(data[0].skill); 
					const markup=`
					<!-- <div class="form-row"> -->
					<div class="container">
					<h2>Update your skills here</h2>
						<div class="form-group">
							<label for="comp_name">Company Name :</label>
							<input type="text"  value="${data[0].companyName}" name="name" id="exp__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Title :</label>
							<input type="text" value="${data[0].title}"name="name" id="title__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Experience in Years :</label>
							<input type="text" value="${data[0].experience}"name="name" id="yr__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Location :</label>
							<input type="text" value="${data[0].location}"name="name" id="loc__" required/>
						</div>
						
						<button type="submit" onclick="updateExp()">Update</button>
					</div>	
					<!-- </div> -->
				   
					`;
					document.querySelector('.container').insertAdjacentHTML("afterend",markup);
				})


					
				}  

				
				async function updateExp() {
					let _Exp_ = localStorage.getItem("_Exp_");
                    let _Title_ = localStorage.getItem("_Title_");
					let exp_ = document.getElementById("exp__").value;
					let title_ = document.getElementById("title__").value;
					let yr_ = document.getElementById("yr__").value;
					let loc_ = document.getElementById("loc__").value;
					// let end_ = document.getElementById("end__").value;
					// let per_ = document.getElementById("per__").value;
					//let skill3 = document.getElementById("skill3").value
				
					// let val = EmailID.split('@');
					// UserID = val[0];
				    // console.log(skill_);
					// console.log(prof_);
					// console.log(Skill_1);
                    console.log();
					fetch("https://localhost:7079/api/Experience/UpdateTrainersExperience?" + new URLSearchParams
						({
							email: EmailID,
							companyName: _Exp_ ,
                            title: _Title_,
							
						}), {
							
						method: "PUT",
				
						body: JSON.stringify({
							emailid: "string",
							companyName: exp_,
							title: title_,
							experience : yr_,
							location : loc_,
							// endYear : end_,
							// percentage : per_,
							//skill_3: skill3
						}),
						headers: {
							"Content-type": "application/json; charset=UTF-8",
						}
					})
						.then((response) =>
						 
						console.log(response))
						window.location.href = "ViewExpDetails.html"
				
					alert("Data Updated")
				}				