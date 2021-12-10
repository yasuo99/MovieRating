using MoviePage.Models;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Tags.Commands
{
    public class UpdateTagCommand: IRequestWrapper<Tag>
    {
        public Tag Tag { get; set; }
    }
    public class UpdateTagHandler : IHandlerWrapper<UpdateTagCommand, Tag>
    {
        public Task<Response<Tag>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
