describe('API AccountingEntry - AddAsync', () => {

    Cypress.config('baseUrl', 'http://localhost:3001/api/')

    let email
    let password

    it('Load data', () => {
        cy.fixture('userLogin').then((user) => {
            email = user.email,
                password = user.password
        })
    })
    var token = ''
    var accountingEntryId = ''

    it('POST - Authenticate', () => {
        cy.request('POST', 'user/Authenticate?email=' + email + '&password=' + password)
            .should((response) => {
                expect(response.status).to.eq(200)
                expect(response.body).to.not.be.null
                expect(response.body.value.token).to.not.be.null
                token = response.body.value.token
            })
    })

    it('PUT - UpdateAsync AccountingEntry with token null', () => {
        const item = {}
        cy.request({ method: 'PUT', url: 'AccountingEntry/UpdateAsync', body: item, failOnStatusCode: false }).its('status').should('eq', 401)
    })

    // add to update test
    //add to delete
    it('POST - AddAsync AccountingEntry', () => {
        const item = {
            "chartAccountId": "411B45BF-EE24-4AED-B221-38993F9CAE9E",
            "value": 30,
            "flowId": "6b26f932-05b2-453b-95ad-cf019c960470",
            "description": "Description Test"
        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'POST', url: 'AccountingEntry/AddAsync', body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(201)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully added")
                accountingEntryId = response.body.value.id
            })
    })

    it('PUT - UpdateAsync AccountingEntry', () => {
        const item = {
            "id": accountingEntryId,
            "chartAccountId": "411B45BF-EE24-4AED-B221-38993F9CAE9E",
            "value": 40,
            "flowId": "6b26f932-05b2-453b-95ad-cf019c960470",
            "description": "Description Test",
            "creationDate": "2022-05-18T00:00:00"
        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'PUT', url: 'AccountingEntry/UpdateAsync', body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(200)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully updated")
            })
    })
})