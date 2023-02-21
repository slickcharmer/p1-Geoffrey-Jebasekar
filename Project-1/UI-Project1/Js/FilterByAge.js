var age = prompt("Enter the age");
fetch("https://localhost:7079/api/Signup/GetAllTrainersByAge?" + new URLSearchParams
        ({
            age : age

            
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('details');
            data.forEach(prof => {
                const educationElement = document.createElement('div');
                educationElement.classList.add('row');
                // <div class = "label">Welcome</div>;
                // <div class="value">${skill.emailid}</div>;
                educationElement.innerHTML = `
                    <div class="label">First Name:</div>
                    <div class="value">${prof.firstname}</div>
                    <div class="label">Last Name:</div>
                    <div class="value">${prof.lastname}</div>
                    <div class="label">Email:</div> 
                    <div class="value">${prof.emailId}</div>
                    <div class="label">Phone Number:</div>
                    <div class="value">${prof.phoneno}</div>
                    <div class="label">Age:</div>
                    <div class="value">${prof.age}</div>
                    <div class="label">City:</div>
                    <div class="value">${prof.city}</div>
                    
                `;
                educationDetailsElement.appendChild(educationElement);
            });
        })
        .catch(error => {
            console.error(error);
            alert('An error occurred while loading education details.');
        });
