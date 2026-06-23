
using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantBusiness.InterfaceServices;
using RestaurantDataAccess.Entities;
using RestaurantShared;
using RestaurantShared.DTOs.PeopleDTOs;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;
using RestaurantShared.Results;
using RestuarantDataAccess.UintOfWork;

namespace RestaurantBusiness.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeopleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }

    
        public async Task<Result<int>> AddNewPersonAsync(CreatePersonDto newPerson)
        {


            if (await isPersonExistAsync(newPerson.NationalNo))
                return Result<int>.Failure("National No is already exist");

      
            var person = new Person
            {
                FirstName = newPerson.FirstName,
                LastName = newPerson.LastName,
                NationalNo = newPerson.NationalNo,
                Phone = newPerson.Phone,
                DateOfBirth = newPerson.DateOfBirth,
                Gender = newPerson.Gender

            };

            await _unitOfWork.peopleRepository.AddAsync(person);

            return await _unitOfWork.SaveChangesAsync()==1? Result<int>.Success(person.PersonId): Result<int>.Failure("Something is wrong");

        }

        public async Task<Result> DeletePersonAsync(int PersonId)
        {
            if (PersonId <= 0 )
                return Result.Failure("id must be a postive");

            if (!await isPersonExistAsync(PersonId))
                return Result.Failure("Person is not exist");

            var person = await _unitOfWork.peopleRepository.GetByIdAsync(PersonId);

            if (person == null)
                return Result.Failure("Person is null");

            _unitOfWork.peopleRepository.DeleteAsync(person);

            return await _unitOfWork.SaveChangesAsync() == 1? Result.Success(): Result.Failure("Something is wrong");

        }

        public async Task<Result<PagedResult<ReadPeopleDto>>> GetAllPeopleAsync(PersonParameter personParameter )
        {
            var People = await _unitOfWork.peopleRepository.GetAll(personParameter);

            if(People == null)
                return Result<PagedResult<ReadPeopleDto>>.Failure("No There are People");

            var PeopleDto = People.Items.Select(p => new ReadPeopleDto
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                NationalNo = p.NationalNo,
                Phone   = p.Phone,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender
            }).ToList();

            var pagedResult = new PagedResult<ReadPeopleDto>
            {
                Items = PeopleDto,
                PageNumber = People.PageNumber,
                PageSize = People.PageSize,
                TotalCount = People.TotalCount
            };

            return  Result<PagedResult<ReadPeopleDto>>.Success(pagedResult);
        }

        public async Task<Result<ReadPeopleDto>> GetPersonAsync(int PersonId)
        {
            if (PersonId <= 0)
                return Result<ReadPeopleDto>.Failure("Id must be a positve");

            var Person = await _unitOfWork.peopleRepository.GetByIdAsync(PersonId);

            if (Person == null)
                return Result<ReadPeopleDto>.Failure("No exists person");

            var PersonDto = new ReadPeopleDto
            {
                PersonId = PersonId,
                FirstName= Person.FirstName,
                LastName= Person.LastName,
                NationalNo= Person.NationalNo,
                Phone= Person.Phone,
                DateOfBirth= Person.DateOfBirth,
                Gender= Person.Gender
            };

            return Result<ReadPeopleDto>.Success(PersonDto);

        }

        public async Task<Result<ReadPeopleDto>> GetPersonAsync(string NationalNo)
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
                return Result<ReadPeopleDto>.Failure("Value must be is not null") ;

            var Person = await _unitOfWork.peopleRepository.GetPersonAsync(NationalNo);

            if (Person == null)
                return Result<ReadPeopleDto>.Failure("No exists person"); 

            var PersonDto = new ReadPeopleDto
            {
                PersonId = Person.PersonId,
                FirstName = Person.FirstName,
                LastName = Person.LastName,
                NationalNo = Person.NationalNo,
                Phone = Person.Phone,
                DateOfBirth = Person.DateOfBirth,
                Gender = Person.Gender
            };

            return Result<ReadPeopleDto>.Success(PersonDto);

        }

        public async Task<bool> isPersonExistAsync(int PersonId)
        {
            if (PersonId <= 0)
                return false;

            return await _unitOfWork.peopleRepository.isExistAsync(PersonId);

        }

        public async Task<bool> isPersonExistAsync(string NationalNo)
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
                return false;

            return await _unitOfWork.peopleRepository.isPersonExist(NationalNo); 
        }

        public async Task<Result> UpdatePersonAsync(int PersonId, UpdatePersonDto person)
        {
            if (PersonId <= 0 )
                return Result.Failure("id must be a positve");

            if (person == null)
                return Result.Failure("person must be a isnt null");

            var PersonToUpdate = await _unitOfWork.peopleRepository.GetByIdAsync(PersonId);

            if(PersonToUpdate == null)
                return Result.Failure("person must be a isnt null");

            

            PersonToUpdate.FirstName = person.FirstName;
            PersonToUpdate.LastName = person.LastName;
            PersonToUpdate.Gender = person.Gender;
            PersonToUpdate.Phone = person.Phone;

            if(PersonToUpdate.NationalNo != person.NationalNo)    
                if (await _unitOfWork.peopleRepository.isPersonExist(person.NationalNo))
                    return Result.Failure("this national no belongs to someone else");

            PersonToUpdate.NationalNo = person.NationalNo;
            PersonToUpdate.DateOfBirth = person.DateOfBirth;

            return await _unitOfWork.SaveChangesAsync() >0? Result.Success(): Result.Failure("Something is wrong");

        }
    
    }
}
