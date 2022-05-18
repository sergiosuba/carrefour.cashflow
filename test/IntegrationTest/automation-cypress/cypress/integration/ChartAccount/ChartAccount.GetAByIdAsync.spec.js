
describe('API ChartAccount - GetAByIdAsync', () => {

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
    var chartAccountId = ''

    it('POST - User.Authenticate', () => {
        cy.request('POST', 'user/Authenticate?email=' + email + '&password=' + password)
            .should((response) => {
                expect(response.status).to.eq(200)
                expect(response.body).to.not.be.null
                expect(response.body.value.token).to.not.be.null
                token = response.body.value.token
            })
    })

    it('GET - ChartAccount.GetByIdAsync with token null', () => {
        const item = {}
        cy.request({ method: 'GET', url: 'ChartAccount/GetByIdAsync?id=0AE65F4B-A62E-4929-9371-F1EC6ACC0EF5', body: item, failOnStatusCode: false }).its('status').should('eq', 401)
    })

    //add to getById
    it('POST - AddAsync ChartAccount', () => {
        const item = {
            "name": "Vendas get by id",
            "description": "Vendas realizadas"
        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'POST', url: 'ChartAccount/AddAsync', body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(201)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully added")
                chartAccountId = response.body.value.id
            })
    })

    it('GET - ChartAccount.GetByIdAsync ChartAccount', () => {
        const item = {

        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'GET', url: 'ChartAccount/GetByIdAsync?id=' + chartAccountId, body: item, headers: header })
            .should((response) => {
                expect(response.status).to.eq(200)
                expect(response.body.value).to.exist
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(200)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully geted")
            })
    })
})